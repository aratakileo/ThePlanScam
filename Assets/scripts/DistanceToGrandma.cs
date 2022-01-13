using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceToGrandma : MonoBehaviour
{
    public Transform player;
    public Transform grandma;
    public TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = $"Расстояние до бабки: {(int)Vector3.Distance(player.position, grandma.position)}";
    }
}
