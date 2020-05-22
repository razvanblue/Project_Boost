using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField] GameObject start;
    [SerializeField] GameObject finish;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    int score1 = 0;
    int score2 = 0;
    int maxScore = 0;

    // Use this for initialization
    void Start () {
        maxScore = (int)((finish.transform.position - start.transform.position).x
            - finish.GetComponent<MeshFilter>().mesh.bounds.size.x * finish.transform.localScale.x / 2);
    }

    // Update is called once per frame
    void Update () {
        int deltaX1 = (int) (player1.transform.position - start.transform.position).x;
        score1 = deltaX1 > score1 ? Mathf.Min(deltaX1, maxScore) : score1;

        int deltaX2 = (int) (player2.transform.position - start.transform.position).x;
        score2 = deltaX2 > score2 ? Mathf.Min(deltaX2, maxScore) : score2;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 20), "Player 1: " + score1);
        GUI.Label(new Rect(10, 20, 150, 30), "Player 2: " + score2);
    }
}
