using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

public class MapGenHandler : MonoBehaviour
{
    [SerializeField]
    private FieldPos[] fieldsPos;

    private int[][] fieldsArray;

    void Start()
    {
        DefineFieldArray();
        CreateMapLayout();
        AssigneFieldType();
    }

    

    private void Awake()
    {
        
    }

    void Update()
    {
        
    }

    private void DefineFieldArray()
    {
        fieldsArray = new int[7][];
        for (int i = 0; i < 7; i++)
        {
            fieldsArray[i] = new int[7];
        }
    }
    
    private void CreateMapLayout()
    {
        SelectOutsideFields();
        SelectExitPoints();
        FillEmptyFields();
    }

    private void SelectOutsideFields()
    {
        for (int x = 0; x < fieldsArray.Length; x++)
        {
            for (int z = 0; z < fieldsArray[x].Length; z++)
            {
                if (x==0 && z==0 || x==6 && z==0 || x==0 && z==6 || x==6 && z==6)
                {
                    fieldsArray[x][z] = 19;
                }
                else if(x==0)
                {
                    fieldsArray[x][z] = 17;
                }
                else if(x==6)
                {
                    fieldsArray[x][z] = 18;
                }
                else if(z==0)
                {
                    fieldsArray[x][z] = 16;
                }
                else if(z==6)
                {
                    fieldsArray[x][z] = 15;
                }
            }
        }
    }
    
    private void SelectExitPoints()
    {
        // Sets Random Bot Exit Pos & Outside Exit Bot
        int rand = Random.Range(1, 6);
        fieldsArray[rand][1] = 8;
        fieldsArray[rand][0] = 12;
        // save Start Pos
        int xPosStart = rand;
        
        // Sets Random Top Exit Pos & Outside Exit Top
        rand = Random.Range(1, 6);
        fieldsArray[rand][5] = 7;
        fieldsArray[rand][6] = 11;
        //save Exit Pos
        int xPosExit = rand;
        
        // Sets Random Left Exit Pos & Outside Exit Left
        rand = Random.Range(2, 5);
        fieldsArray[1][rand] = 9;
        fieldsArray[0][rand] = 13;
        
        // Sets Random Right Exit Pos & Outside Exit Right
        rand = Random.Range(2, 5);
        fieldsArray[5][rand] = 10;
        fieldsArray[6][rand] = 14;
        
        
        CreateRoadLayout(xPosStart, xPosExit);
    }
    
    private void CreateRoadLayout(int xPosStart, int xPosExit)
    {
        bool isNextBlockExit = false;
        int xPos = xPosStart;
        int zPos = 1;
        int counter = 0;
        do
        {
            switch (Random.Range(1,4))
            {
                // Left
                case 1: 
                {
                    
                    // Break if Exit in different dir
                    if (zPos == 5 && xPosExit > xPos)
                    {
                        break;
                    }
                    // Is the next Field Empty, ExitLeft or ExitTop?
                    if (IsFieldEmpty(xPos-1, zPos) || fieldsArray[xPos-1][zPos] == 9 || fieldsArray[xPos-1][zPos] == 7)
                    {
                        // Replace the last Field
                        if (IsFieldEmpty(xPos, zPos))
                        {
                            fieldsArray[xPos][zPos] = 1;
                        }
                        xPos -= 1;
                    }
                    break;
                }
                // Top
                case 2:
                {
                    if (IsFieldEmpty(xPos, zPos+1) || fieldsArray[xPos][zPos+1] == 10 || fieldsArray[xPos][zPos+1] == 9 || fieldsArray[xPos][zPos+1] == 7)
                    {
                        // Replace the last Field
                        if (IsFieldEmpty(xPos, zPos))
                        {
                            fieldsArray[xPos][zPos] = 1;
                        }
                        zPos += 1;
                    }
                    break;
                }
                // Right
                case 3:
                {
                    // Break if Exit in different dir
                    if (zPos == 5 && xPosExit < xPos)
                    {
                        break;
                    }
                    if (IsFieldEmpty(xPos+1, zPos) || fieldsArray[xPos+1][zPos] == 10 || fieldsArray[xPos+1][zPos] == 7)
                    {
                        // Replace the last Field
                        if (IsFieldEmpty(xPos, zPos))
                        {
                            fieldsArray[xPos][zPos] = 1;
                        }
                        xPos += 1;
                    }
                    break;
                }
                default:
                    break;
            }
            if (fieldsArray[xPos][zPos] == 7)
            {
                isNextBlockExit = true;
            }

            counter++;
            if (counter==200)
            {
                Debug.Log("Counter bei 1000" + xPos + zPos);
                isNextBlockExit = true;
            }
        } while (!isNextBlockExit);
    }

    private bool IsFieldEmpty(int xPos, int zPos)
    {
        if (fieldsArray[xPos][zPos] == 0)
        {
            return true;
        }
        return false;
    }
    
    private void FillEmptyFields()
    {
        for (int x = 0; x < fieldsArray.Length; x++)
        {
            for (int z = 0; z < fieldsArray[x].Length; z++)
            {
                if (fieldsArray[x][z] == 0)
                {
                    fieldsArray[x][z] = Random.Range(4, 7);
                }
            }
        }
        Debug.Log("Map Loaded");
    }
    
    private void AssigneFieldType()
    {
        /*
        foreach (FieldPos field in fieldsPos)
        {
            field.Type = (FieldPos.FieldType)(fieldsArray[field.ArrayPosX][field.ArrayPosZ]);
            Debug.Log(field.Type.ToString());
        }
        */
        for (int i = 0; i < 49; i++)
        {
            fieldsPos[i].Type = (FieldPos.FieldType)(fieldsArray[fieldsPos[i].ArrayPosX][fieldsPos[i].ArrayPosZ]);
            Debug.Log(i + "\nType " + fieldsPos[i].Type + "\nPosX " +  fieldsPos[i].ArrayPosX + "\nPosY" + fieldsPos[i].ArrayPosZ + "\nUebergebene Enum Index" + fieldsArray[fieldsPos[i].ArrayPosX][fieldsPos[i].ArrayPosZ]);
        }
    }
    
    
}
