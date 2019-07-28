using UnityEngine;

public class Waypoints : MonoBehaviour {

    
    public static Transform[] points;
    public Transform[] Points
    {
        get
        {
            return points;
        }
    }

    void Awake()
    {
        points = new Transform[transform.childCount];
        
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
