using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string _filePath;
    public List<GameObject> PlanetList;

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/save.sbin";
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Create);
        Save save = new Save();
        save.SavePlanets(PlanetList);
        //save.HpPlanet = PlanetList
        bf.Serialize(fs, save);
        fs.Close();
    }

    public void Loaded()
    {
        if(!File.Exists(_filePath))
        {
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Open);
        Save save = (Save)bf.Deserialize(fs);

        fs.Close();
        var dataCont = save.PlanetData.Count;
        for(var i = 0; i< dataCont; i++)
        {
            PlanetList[i].GetComponent<PlanetAi>().LoadData(save.PlanetData[i]);
        }
    }
}

[System.Serializable]
public class Save
{
    public float HpPlanet;
    [System.Serializable]
    public struct PlaetSaveData
    {
        public float RotationPosition;
        public int HpPlanet;

        public PlaetSaveData(float rot, int hp)
        {
            RotationPosition = rot;
            HpPlanet = hp;
        }
    }
    public List<PlaetSaveData> PlanetData = new List<PlaetSaveData>();

    public void SavePlanets(List<GameObject> Planets)
    {
        foreach(var planet in Planets)
        {
            float RotationPosition = planet.transform.localRotation.z;
            int hp = planet.GetComponent<PlanetAi>().HpPlanet;
            PlanetData.Add(new PlaetSaveData(RotationPosition, hp));
        }
    }
}

