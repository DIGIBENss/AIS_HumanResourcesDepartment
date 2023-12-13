using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServicePosition
{
    DB db;

    public ServicePosition()
    {
        db = new DB();
    }
    public int GetNewID()
    {
        var conn = db.GetConnection();
        var maxId = conn.Table<Position>().Max(o => (int?)o.ID_Position) ?? 0;
        return maxId + 1;
    }
    public IEnumerable<Position> GetEmployeesNames(string name)
    {
        return db.GetConnection().Table<Position>().Where(x => x.Position_Name == name);
    }
    public Position GetEmployeeName(string name)
    {
        return db.GetConnection().Table<Position>().Where(x => x.Position_Name == name).FirstOrDefault();
    }
    public IEnumerable<Position> GetPositionsID(int id)
    {
        return db.GetConnection().Table<Position>().Where(x => x.ID_Position == id);
    }
    public Position GetPositionID(int id)
    {
        return db.GetConnection().Table<Position>().Where(x => x.ID_Position == id).FirstOrDefault();
    }
}
