using SQLite4Unity3d;
public class Participation_In_Training
{
    [PrimaryKey, AutoIncrement] 
    public int ID_Participation{ get; set; }
    public int Employee_ID { get; set; }
    public int Trainig_ID { get; set; }
    public string Status_Participation { get; set; }
    public float Evaluation { get; set; }
    public string Feedback { get; set; }
}
