using SQLite4Unity3d;
using System;
public class Training
{
    [PrimaryKey, AutoIncrement] 
    public int ID_Training { get; set; }
    public string Course_Name { get; set; }
    public string Organization { get; set; }
    public float Cost { get; set; }
    public DateTime Start_Data { get; set; }
    public DateTime End_Data { get; set; }
}
