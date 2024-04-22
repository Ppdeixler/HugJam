using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TurnMath : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManagerObject;

    //Text UI Report

    [SerializeField]
    private TMP_Text desastreTurno;

    private string desabamento = "Desabamento";
    private string Enchente = "Enchente";
    private string incendio = "Incêndio Florestal";

    [SerializeField]
    private TMP_Text construçõesDestruídas;

    [SerializeField]
    private TMP_Text mortos;

    [SerializeField]
    private TMP_Text socorridos;

    [SerializeField]
    private TMP_Text casasAGanhar;

    //Report Variables

    private int deathsInTotal;
    private int buildingsDemolishedInTotal;
    private int helpedPeopleInTotal;

    private int casasAGanharThisRound;

    //Amount Of Good Buildings

    private int totalOfHouses;

    public enum Desastres {Deslizamento, Enchente, Incendio };

    public Desastres desastres;

    //UI Mechanics

    [SerializeField]
    private GameObject canvasReport;

    [SerializeField]
    private _TileScript[] tiles;

    public bool isObjectsInstantiated = false;

    public static bool inReport;

    public static int roundsPassed;

    private void Start()
    {
        roundsPassed = 0;
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        
    }

    public IEnumerator StartGame()
    {
        yield return new WaitUntil(() => isObjectsInstantiated == true);

        tiles = new _TileScript[gameManagerObject.transform.childCount];
        Debug.Log(gameManagerObject.transform.childCount);

        tiles = GetComponentsInChildren<_TileScript>();
    }

    public void ReportStart()
    {
        inReport = true;
        Luck();
        DemolishCalculations();
        HousesToWin();
        UIUpdate();
    }



    public void Luck()
    {
        int luckInt = Random.Range(0, 3);

        switch (luckInt)
        {
            case 0:
                desastres = Desastres.Enchente;
                break;
            case 1:
                desastres = Desastres.Deslizamento;
                break;
            case 2:
                desastres = Desastres.Incendio;
                break;

        }
    }

    public void TurnPass()
    {
        Resources.houses += casasAGanharThisRound;
        Resources.firefightbuild += Random.Range(0, 1);
        Resources.hospital += Random.Range(0, 1);

        canvasReport.SetActive(false);
        inReport = false;
        roundsPassed++;
    }

    public void UIUpdate()
    {
        canvasReport.SetActive(true);

        switch (desastres)
        {
            case Desastres.Deslizamento:
                desastreTurno.text = desabamento;
                break;
            case Desastres.Enchente:
                desastreTurno.text = Enchente;
                break;
            case Desastres.Incendio:
                desastreTurno.text = incendio;
                break;
        }

        construçõesDestruídas.text = buildingsDemolishedInTotal.ToString();
        mortos.text = deathsInTotal.ToString();
        socorridos.text = helpedPeopleInTotal.ToString();
        casasAGanhar.text = casasAGanharThisRound.ToString();

    }





    public void DemolishCalculations()
    {

        totalOfHouses = 0;

        foreach (_TileScript tile in tiles)
        {
            if (tile.built)
            {

                    if (tile.ActualTerrain == _TileScript.terrain.Mountain && desastres == Desastres.Deslizamento)
                    {
                        tile.DemolishHere();
                        deathsInTotal += Random.Range(0, 10);
                        buildingsDemolishedInTotal++;
                        helpedPeopleInTotal += Random.Range(0, 5);
                    }

                    if (tile.ActualTerrain == _TileScript.terrain.River && desastres == Desastres.Enchente)
                    {
                        tile.DemolishHere();
                        deathsInTotal += Random.Range(0, 10);
                        buildingsDemolishedInTotal++;
                        helpedPeopleInTotal += Random.Range(0, 5);
                    }

                    if (tile.ActualTerrain == _TileScript.terrain.Forest && desastres == Desastres.Incendio)
                    {
                        tile.DemolishHere();
                        deathsInTotal += Random.Range(0, 10);
                        buildingsDemolishedInTotal++;
                        helpedPeopleInTotal += Random.Range(0, 5);
                    }
                totalOfHouses++;
            }
            
        }

    }

    


    public void HousesToWin()
    {

        foreach (_TileScript tile in tiles)
        {
            if (tile.built)
            {
                casasAGanharThisRound = totalOfHouses - 4 * roundsPassed;
            }
        }

    }



}
