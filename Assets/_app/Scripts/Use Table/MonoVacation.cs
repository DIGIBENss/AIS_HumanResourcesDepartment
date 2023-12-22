using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonoVacation : MonoBehaviour
{
    private Service _service;
    [SerializeField] private TableDisplay _tabledisplay;
    public ServiceVacation ServiceVacation;
    private void Start()
    {
        _service = new Service();
        ServiceVacation = new ServiceVacation();
    }
    public void OnGetDataVacation()
    {
        _tabledisplay.ClearTable();
        var vacations = _service.GetAll<Vacation>();
        var empolyees = _service.GetAll<Employee>();
        foreach (var vacation in vacations)
        {
            Employee vacationEmpolyee = empolyees.FirstOrDefault(p => p.ID_Employee == vacation.Employee_ID);
            if (vacationEmpolyee != null)
            {
                _tabledisplay.CreateVacationDisplay(vacationEmpolyee, vacation);
            }
        }
    }
    public void AddVacationDateTable()
    {
        int nextpositionid = ServiceVacation.GetNewID();
        Vacation newParticipation = new Vacation
        {
            ID_Vacation = nextpositionid,
            Employee_ID = -1
        };
        _service.Add(newParticipation);
        OnGetDataVacation();
    }
}
