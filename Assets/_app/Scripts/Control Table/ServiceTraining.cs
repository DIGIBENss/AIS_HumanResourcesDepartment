using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServiceTraining
{
    DB db;
    public ServiceTraining()
    {
        db = new DB();
    }
    public int GetNewID()
    {
        var conn = db.GetConnection();
        var maxId = conn.Table<Training>().Max(o => (int?)o.ID_Training) ?? 0;
        return maxId + 1;
    }
    public IEnumerable<Training> GetTrainingsID(int id)
    {
        return db.GetConnection().Table<Training>().Where(x => x.ID_Training == id);
    }
    public Training GetTrainingID(int id)
    {
        return db.GetConnection().Table<Training>().Where(x => x.ID_Training == id).FirstOrDefault();
    }
}
