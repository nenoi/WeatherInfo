using UnityEngine;

[System.Serializable]
public class WeatherEntity {
    public string name;
    public Weather[] weather;
    public Temperature main;
    public Wind wind;
}

[System.Serializable]
public class Weather {
    public string main; // Rain, Snow, Clouds ... etc
}

[System.Serializable]
public class Temperature {
    public float temp; // 現在の気温
}

[System.Serializable]
public class Wind {
    public float deg;
    public float speed;
}
