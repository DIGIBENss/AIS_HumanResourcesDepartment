using UnityEngine;
using System.Linq;

public class MonoTraining : MonoBehaviour
{
    private Service _service;
    [SerializeField] private TableDisplay _tabledisplay;
    public ServiceParticipation ServiceParticipation;
    public ServiceTraining ServiceTraining;
    private void Start()
    {
        _service = new Service();
        ServiceParticipation = new ServiceParticipation();
        ServiceTraining = new ServiceTraining();
    }
    public void OnGetDataTraining()
    {
        _tabledisplay.ClearTable();
        var trainings = _service.GetAll<Training>();
        var participations = _service.GetAll<Participation_In_Training>();
        foreach (var training in trainings)
        {
            Participation_In_Training trainingparticipation = participations.FirstOrDefault(p => p.Trainig_ID == training.ID_Training);
            if (trainingparticipation != null)
            {
                _tabledisplay.CreateTrainingDisplay(trainingparticipation, training);
            }
        }
    }
    public void AddPositionDateTable()
    {
        int nextpositionid = ServiceParticipation.GetNewID();
        int nexttrainingid = ServiceTraining.GetNewID();
        Participation_In_Training newParticipation = new Participation_In_Training
        {
            ID_Participation = nextpositionid,
            Trainig_ID = nexttrainingid,
            Employee_ID = -1
        };
        Training newtraining = new Training
        {
            ID_Training = nexttrainingid
        };
        _service.Add(newParticipation);
        _service.Add(newtraining);
        OnGetDataTraining();
    }
}
