using UPB.PracticeTwo.Models;

namespace UPB.PracticeTwo.Managers;

public class StudentManager
{
    private List<Student> _students;
    public StudentManager()
    {
        _students = new List<Student>();
    }
    public List<Student> GetAll()
    {
        return _students;
    }

    public Student GetById(int ci)
    {
        return _students.Find(student => student.CI == ci);
    }

    public Student Update(int ci)
    {
        if (ci < 0)
        {
            throw new Exception("CI invalido");
        }

        Student studentFound;
        studentFound = _students.Find(student => student.CI == ci);

        if (studentFound == null)
        {
            throw new Exception("no se encontro un estudiante");
        }
        studentFound.Name = "Cambiado";

        return studentFound;
    }
    public Student Create(string name, int age, int ci)
    {
        Student createdStudent = new Student()
        {
            Name = name,
            Age = age,
            CI = ci
        };
        _students.Add(createdStudent);
        return createdStudent;
    }

    public Student Delete(int ci)
    {
        int studentToDeleteIndex = _students.FindIndex(student => student.CI == ci);
        Student studentToDelete = _students[studentToDeleteIndex];
        _students.RemoveAt(studentToDeleteIndex);
        return studentToDelete;
    }
}
