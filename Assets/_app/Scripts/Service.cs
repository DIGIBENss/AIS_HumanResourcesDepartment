using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Service
{
    DB db;

    public Service()
    {
        db = new DB();
    }
    public void CreateTable()
    {
        db.GetConnection().DropTable<Employee>();
        db.GetConnection().CreateTable<Employee>();

        db.GetConnection().DropTable<Vacation>();
        db.GetConnection().CreateTable<Vacation>();

        db.GetConnection().DropTable<Position>();
        db.GetConnection().CreateTable<Position>();

        db.GetConnection().DropTable<Training>();
        db.GetConnection().CreateTable<Training>();

        db.GetConnection().DropTable<Participation_In_Training>();
        db.GetConnection().CreateTable<Participation_In_Training>();

    }
    public int Add<T>(T entity) where T : class
    {
        return db.GetConnection().Insert(entity);
    }

    public int AddMany<T>(T[] entities) where T : class
    {
        return db.GetConnection().InsertAll(entities);
    }

    public IEnumerable<T> GetAll<T>() where T : class, new()
    {
        return db.GetConnection().Table<T>();
    }
    public int Delete<T>(T entity) where T : class
    {
        return db.GetConnection().Delete(entity);
    }

    public int Update<T>(T entity) where T : class
    {
        return db.GetConnection().Update(entity);
    }

    public int UpdateMany<T>(T[] entities) where T : class
    {
        return db.GetConnection().UpdateAll(entities);
    }
}

