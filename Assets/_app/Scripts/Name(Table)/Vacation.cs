using SQLite4Unity3d;
public class Vacation
{
    [PrimaryKey, AutoIncrement] public int ID_Vacation { get; set; }
    public int ID_Employee { get; set; }
    public string Start_date { get; set; }
    public string End_date { get; set; }
    public string Type_of_vacation { get; set; }
    public override string ToString()
    {
        return string.Format("[Vacation: ID_Vacation={0}, ID_Employee={1}, Start_date={2},  End_date={3}, Type_of_vacation={4}]", ID_Vacation, ID_Employee, Start_date, End_date, Type_of_vacation);
    }
}
