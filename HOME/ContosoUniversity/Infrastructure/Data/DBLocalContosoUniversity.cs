using ContosoUniversity.Domain.Entities.Base;
using System.Text.Json;



namespace ContosoUniversity.Infrastructure.Data
{
    public class DBLocalContosoUniversity
    {
    private const string _fileNamePersons = "dbContosoUniversityPersons.json";
    private const string _fileNameCourses = "dbContosoUniversityCourses.json";
    private const string _fileNameDepartaments = "dbContosoUniversityDepartaments.json";
    private const string _dataPath = "Infrastructure\\Data";
    private IEnumerable<Person> _persons;
     private IEnumerable<Course> _course;
    private IEnumerable<Departaments> _departaments;
    
    private string GetPathFile(string fileName)
    {
    return Path.Combine(Environment.CurrentDirectory, _dataPath, fileName);
    }

    private T JsonDeserialize<T>(string filePath)
        {
        var jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString)!;
        }

    private void LoadDataCourses()
    {
    var filePath = GetPathFile(_fileNameCourses);
    if (File.Exists(filePath))
    _course = JsonDeserialize<IEnumerable<Course>>(filePath);
    }


    private void LoadDataDepartaments()
        {
        var filePath = GetPathFile(_fileNameDepartaments);
        if (File.Exists(filePath))
        _departaments = JsonDeserialize<IEnumerable<Departaments>>(filePath);
        }

    private void LoadDataPerson()
        {
        var filePath = GetPathFile( _fileNamePersons);
        if (File.Exists(filePath))
        _persons = JsonDeserialize<IEnumerable<Person>>(filePath);
        }
    
    public IEnumerable<Course> Courses {
        get{
        LoadDataCourses();
        return _course;
        }
    }

    public IEnumerable<Departaments> departaments {
        get{
        LoadDataDepartaments();
        return _departaments;
        }
    }

    public IEnumerable<Person> person{
        get{
        LoadDataPerson();
        return _persons;
        }
    }

        public DBLocalContosoUniversity()
        {
            _persons = new List<Person>();

            _course = new List<Course>();

            _departaments = new List<Departaments>();
   
        }
    }
}
