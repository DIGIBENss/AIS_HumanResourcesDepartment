using SQLite4Unity3d;

public class Employee
{
    [PrimaryKey, AutoIncrement]
    public int ID_Employee { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Data_of_birth { get; set; }
    public string Data_of_reception { get; set; }
    public string Phone_number { get; set; }
    public string Email { get; set; }
    public int ID_Position { get; set; }

}
