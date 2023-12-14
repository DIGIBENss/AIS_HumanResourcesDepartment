using SQLite4Unity3d;
using System;

public class Vacation
{
    [PrimaryKey, AutoIncrement] 
    public int ID_Vacation { get; set; }
    public DateTime Start_date { get; set; }
    public DateTime End_date { get; set; }
    public string Type_of_vacation { get; set; }
    public int Employee_ID { get; set; }
}
