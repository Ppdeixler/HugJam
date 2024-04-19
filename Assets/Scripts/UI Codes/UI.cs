using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text houses;

    [SerializeField]
    private TMP_Text firefighters;

    [SerializeField]
    private TMP_Text hospitals;

    private void Update()
    {
        houses.text = Resources.houses.ToString();
        firefighters.text = Resources.firefightbuild.ToString();
        hospitals.text = Resources.hospital.ToString();
    }


}
