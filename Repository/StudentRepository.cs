using Microsoft.EntityFrameworkCore;
using static StudentModel;
using static MvcStudentContext;


public class StudentRepository : IStudentRepository {
  private MvcStudentContext db = null;

  public StudentRepository() {
    this.db = new MvcStudentContext(null);
  }

  public StudentRepository(MvcStudentContext db) {
    this.db = db;
  }

  public IEnumerable<StudentModel> SelectAll() {
    return db.StudentModel.OrderBy(s => s.Surname).ToList();
  }

  public StudentModel SelectByID(int ID) {
    return db.StudentModel.Find(ID);
  }

  public void Insert(StudentModel student) {
    db.StudentModel.Add(student);
  }

  public void Update(StudentModel student) {
    db.Entry(student).State = EntityState.Modified;
  }

  public void Delete(int ID, int? replacementID) {
    StudentModel existing = db.StudentModel.Find(ID);
    db.StudentModel.Remove(existing);
  }

  public void Save() {
    db.SaveChanges();
  }

  public IEnumerable<String> CountryList() {
    var listOfCountries = File.ReadLines("countries.list").Select(line => new String(line)).ToList();
    return listOfCountries;
  }
}
