using SQLite4Unity3d;
public class Participation_In_Training
{
    [PrimaryKey, AutoIncrement] public int ID_Participation{ get; set; }
    public int Employee_ID { get; set; }
    public int Trainig_ID { get; set; }
    public string Satus_Participation { get; set; }
    public float Evaluation { get; set; }
    public string Feedback { get; set; }
    public override string ToString()
    {
        return string.Format("[Training: ID_Participation={0}, Employee_ID={1}, Trainig_ID={2},  Satus_Participation ={3}, Evaluation={4}, Feedback={5} ]", ID_Participation, Employee_ID, Trainig_ID,  Satus_Participation, Evaluation, Feedback);
    }
}
