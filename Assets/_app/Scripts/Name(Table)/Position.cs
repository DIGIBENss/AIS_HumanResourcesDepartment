using SQLite4Unity3d;
public class Position
{
    [PrimaryKey, AutoIncrement] 
    public int ID_Position { get; set; }
    public string Position_Name { get; set; }
    public string Description_Position { get; set; }
    public string Basic_date { get; set; }
    public override string ToString()
    {
        return string.Format("[Vacation: ID_Position={0}, Name_Position={1}, Description_Position={2},  Basic_date={3}]", ID_Position, Position_Name, Description_Position, Basic_date);
    }
}
