using static StudentModel;

interface IStudentRepository{
  IEnumerable<StudentModel> SelectAll();
  StudentModel SelectByID(int id);
  void Insert(StudentModel student);
  void Update(StudentModel student);
  void Delete(int id, int? replacementID);
  void Save();
}
