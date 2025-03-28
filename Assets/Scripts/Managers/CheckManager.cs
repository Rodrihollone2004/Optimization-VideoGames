using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    [SerializeField] List<char> checkX;
    [SerializeField] int countX;

    public List<char> CheckX { get => checkX; private set => checkX = value; }

    private void Awake()
    {
        checkX = new List<char>();
    }

    private void Update()
    {
        //LinqCheckX();
        //ForEachCheckX();
        ForCheckX();
    }

    public void LinqCheckX()
    {
        countX = checkX.Count(c => c == 'X');

        if (countX >= 5)
        {
            Debug.Log("QUINTA X (LINQ)");
            countX = 0;
            checkX.Clear();
        }
    }

    public void ForEachCheckX()
    {
        if (countX < 5)
        {
            List<char> toRemove = new List<char>();

            foreach (char c in checkX)
            {
                if (c == 'X')
                {
                    countX++;
                    toRemove.Add(c);
                }
            }

            foreach (char c in toRemove)
            {
                checkX.Remove(c);
            }
        }
        else if (countX >= 5)
        {
            Debug.Log("QUINTA X (FOR EACH)");
            countX = 0;
            checkX.Clear();
        }
    }

    public void ForCheckX()
    {
        if (countX < 5)
        {
            for (int i = 0; i < checkX.Count; i++)
            {
                if (checkX.Contains('X'))
                {
                    countX++;
                    checkX.Remove('X');
                }
            }
        }
        else if (countX >= 5)
        {
            Debug.Log("QUINTA X (FOR)");
            countX = 0;
            checkX.Clear();
        }
    }
}
