using SQLite4Unity3d;
public class Training
{
    [PrimaryKey, AutoIncrement] public int ID_Training { get; set; }
    public string Course_Name { get; set; }
    public string Organization { get; set; }
    public float Cost { get; set; }
    public string Start_Data { get; set; }
    public string End_Data { get; set; }
    public override string ToString()
    {
        return string.Format("[Training: ID_Training={0}, Course_Name={1}, Organization={2},  Cost={3}, Start_Data={4}, End_Data={5} ]", ID_Training, Course_Name, Organization, Cost, Start_Data, End_Data);
    }
}
