using SQLite4Unity3d;
using System;

public class Vacation
{
    [PrimaryKey, AutoIncrement] 
    public int ID_Vacation { get; set; }
    public string Start_date { get; set; }
    public string End_date { get; set; }
    public string Type_of_vacation { get; set; }
    public int Employee_ID { get; set; }
}
