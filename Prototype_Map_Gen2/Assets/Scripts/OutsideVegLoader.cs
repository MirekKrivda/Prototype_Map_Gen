using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideVegLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] topVegPF;
    [SerializeField] private GameObject[] botVegPF;
    [SerializeField] private GameObject[] leftVegPF;
    [SerializeField] private GameObject[] rightVegPF;
    [SerializeField] private GameObject[] centerVegPF;
    
    [SerializeField] private GameObject[] topFencePF;
    [SerializeField] private GameObject[] botFencePF;
    [SerializeField] private GameObject[] leftFencePF;
    [SerializeField] private GameObject[] rightFencePF;

    [SerializeField] private PrefabCollection prefabCollection;
    
    void Awake()
    {
        prefabCollection = GameObject.Find("PrefabCollection").GetComponent<PrefabCollection>();
    }
    
    public void LoadFieldType(FieldPos.FieldType type)
    {
        switch (type)
        {
            case FieldPos.FieldType.Road:
                LoadRoadField();
                break;
            case FieldPos.FieldType.NoVeg:
                LoadNoVegField();
                break;
            case FieldPos.FieldType.LowVeg:
                LoadLowVegField();
                break;
            case FieldPos.FieldType.HighVeg:
                LoadHighVegField();
                break;
            case FieldPos.FieldType.ExitBot:
                LoadRoadField();
                break;
            case FieldPos.FieldType.ExitTop:
                LoadRoadField();
                break;
            case FieldPos.FieldType.ExitLeft:
                LoadRoadField();
                break;
            case FieldPos.FieldType.ExitRight:
                LoadRoadField();
                break;
            case FieldPos.FieldType.OutsideExitTop:
                LoadOutsideExitTopField();
                break;
            case FieldPos.FieldType.OutsideExitBot:
                LoadOutsideExitBotField();
                break;
            case FieldPos.FieldType.OutsideExitLeft:
                LoadOutsideExitLeftField();
                break;
            case FieldPos.FieldType.OutsideExitRight:
                LoadOutsideExitRightField();
                break;
            case FieldPos.FieldType.OutsideTop:
                LoadOutsideTopField();
                break;
            case FieldPos.FieldType.OutsideBot:
                LoadOutsideBotField();
                break;
            case FieldPos.FieldType.OutsideLeft:
                LoadOutsideLeftField();
                break;
            case FieldPos.FieldType.OutsideRight:
                LoadOutsideRightField();
                break;
            case FieldPos.FieldType.OutsideCorner:
                LoadHighVegField();
                break;
            default:
                break;
        }
    }

    public void LoadRoadField()
    {
        LoadLowTopVeg();
        LoadLowBotVeg();
        LoadLowLeftVeg();
        LoadLowRightVeg();
        LoadLowCenterVeg();
    }
    
    public void LoadNoVegField()
    {
        LoadLowTopVeg();
        LoadLowBotVeg();
        LoadLowLeftVeg();
        LoadLowRightVeg();
        LoadLowCenterVeg();
    }
    public void LoadLowVegField()
    {
        LoadLowTopVeg();
        LoadLowBotVeg();
        LoadLowLeftVeg();
        LoadLowRightVeg();
        LoadLowCenterVeg();
        
        LoadMidTopVeg();
        LoadMidBotVeg();
        LoadMidLeftVeg();
        LoadMidRightVeg();
        LoadMidCenterVeg();
    }
    public void LoadHighVegField()
    {
        LoadLowTopVeg();
        LoadLowBotVeg();
        LoadLowLeftVeg();
        LoadLowRightVeg();
        LoadLowCenterVeg();
        
        LoadMidTopVeg();
        LoadMidBotVeg();
        LoadMidLeftVeg();
        LoadMidRightVeg();
        LoadMidCenterVeg();
        
        LoadHighTopVeg();
        LoadHighBotVeg();
        LoadHighLeftVeg();
        LoadHighRightVeg();
        LoadHighCenterVeg();
    }

    public void LoadOutsideTopField()
    {
        LoadHighVegField();
        LoadBotFence();
    }
    public void LoadOutsideBotField()
    {
        LoadHighVegField();
        LoadTopFence();
    }
    public void LoadOutsideLeftField()
    {
        LoadHighVegField();
        LoadRightFence();
    }
    public void LoadOutsideRightField()
    {
        LoadHighVegField();
        LoadLeftFence();
    }

    public void LoadOutsideExitTopField()
    {
        LoadLowTopVeg();
        LoadLowBotVeg();
        LoadLowLeftVeg();
        LoadLowRightVeg();
        LoadLowCenterVeg();
        
        LoadMidLeftVeg();
        LoadMidRightVeg();
    }
    public void LoadOutsideExitBotField()
    {
        LoadLowTopVeg();
        LoadLowBotVeg();
        LoadLowLeftVeg();
        LoadLowRightVeg();
        LoadLowCenterVeg();
        
        LoadMidLeftVeg();
        LoadMidRightVeg();
    }
    public void LoadOutsideExitLeftField()
    {
        LoadLowTopVeg();
        LoadLowBotVeg();
        LoadLowLeftVeg();
        LoadLowRightVeg();
        LoadLowCenterVeg();
        
        LoadMidTopVeg();
        LoadMidBotVeg();
    }
    public void LoadOutsideExitRightField()
    {
        LoadLowTopVeg();
        LoadLowBotVeg();
        LoadLowLeftVeg();
        LoadLowRightVeg();
        LoadLowCenterVeg();
        
        LoadMidTopVeg();
        LoadMidBotVeg();
    }
    
    private void LoadHighTopVeg()
    {
        for (int i = 0; i < topVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0,3))
                                {
                                    case 0:
                                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), topVegPF[i].transform.position, Quaternion.identity);
                                        break;
                                    case 1:
                                        Instantiate(prefabCollection.GetRandomMidGreenPF(), topVegPF[i].transform.position, Quaternion.identity);
                                        break;
                                    case 2:
                                        Instantiate(prefabCollection.GetRandomHighGreenPF(), topVegPF[i].transform.position, Quaternion.identity);
                                        break;
                                }
            }
            
            Destroy(topVegPF[i]);
        }
    }
    private void LoadHighBotVeg()
    {
        for (int i = 0; i < botVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), botVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), botVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(prefabCollection.GetRandomHighGreenPF(), botVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }
            Destroy(botVegPF[i]);
        }
    }
    private void LoadHighLeftVeg()
    {
        for (int i = 0; i < leftVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), leftVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), leftVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(prefabCollection.GetRandomHighGreenPF(), leftVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }
            Destroy(leftVegPF[i]);
        }
    }
    private void LoadHighRightVeg()
    {
        for (int i = 0; i < rightVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), rightVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), rightVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(prefabCollection.GetRandomHighGreenPF(), rightVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }
            Destroy(rightVegPF[i]);
        }
    }
    private void LoadHighCenterVeg()
    {
        for (int i = 0; i < centerVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), centerVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), centerVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(prefabCollection.GetRandomHighGreenPF(), centerVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }

            Destroy(centerVegPF[i]);
        }
    }
    
    private void LoadMidTopVeg()
    {
        for (int i = 0; i < topVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), topVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), topVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }
            Destroy(topVegPF[i]);
        }
    }
    private void LoadMidBotVeg()
    {
        for (int i = 0; i < botVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), botVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), botVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }
            Destroy(botVegPF[i]);
        }
    }
    private void LoadMidLeftVeg()
    {
        for (int i = 0; i < leftVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), leftVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), leftVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }
            Destroy(leftVegPF[i]);
        }
    }
    private void LoadMidRightVeg()
    {
        for (int i = 0; i < rightVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), rightVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), rightVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }
            Destroy(rightVegPF[i]);
        }
    }
    private void LoadMidCenterVeg()
    {
        for (int i = 0; i < centerVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        Instantiate(prefabCollection.GetRandomSmalGreenPF(), centerVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(prefabCollection.GetRandomMidGreenPF(), centerVegPF[i].transform.position,
                            Quaternion.identity);
                        break;
                }
            }
            Destroy(centerVegPF[i]);
        }
    }
    
    private void LoadLowTopVeg()
    {
        for (int i = 0; i < topVegPF.Length; i++)
        {
            if (Random.Range(0,2)==1)
            {
                Instantiate(prefabCollection.GetRandomSmalGreenPF(), topVegPF[i].transform.position, Quaternion.identity);
            }
            Destroy(topVegPF[i]); 
        }
    }
    private void LoadLowBotVeg()
    {
        
            for (int i = 0; i < botVegPF.Length; i++)
            {
                if (Random.Range(0, 2) == 1)
                {
                    Instantiate(prefabCollection.GetRandomSmalGreenPF(), botVegPF[i].transform.position,
                        Quaternion.identity);
                }
                Destroy(botVegPF[i]);
            }
    }
    private void LoadLowLeftVeg()
    {
        for (int i = 0; i < leftVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(prefabCollection.GetRandomSmalGreenPF(), leftVegPF[i].transform.position,
                    Quaternion.identity);
            }
            Destroy(leftVegPF[i]);
        }
    }
    private void LoadLowRightVeg()
    {
        for (int i = 0; i < rightVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(prefabCollection.GetRandomSmalGreenPF(), rightVegPF[i].transform.position,
                    Quaternion.identity);
            }
            Destroy(rightVegPF[i]);
        }
    }
    private void LoadLowCenterVeg()
    {
        for (int i = 0; i < centerVegPF.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(prefabCollection.GetRandomSmalGreenPF(), centerVegPF[i].transform.position,
                    Quaternion.identity);
            }
            Destroy(centerVegPF[i]);
        }
    }

    private void LoadTopFence()
    {
        for (int i = 0; i < topFencePF.Length; i++)
        {
            Instantiate(prefabCollection.GetRandomHFencePFPF(), topFencePF[i].transform.position, Quaternion.identity);
            Destroy(topFencePF[i]);
        }
    }
    private void LoadBotFence()
    {
        for (int i = 0; i < botFencePF.Length; i++)
        {
            Instantiate(prefabCollection.GetRandomHFencePFPF(), botFencePF[i].transform.position, Quaternion.identity);
            Destroy(botFencePF[i]);
        }
    }
    private void LoadLeftFence()
    {
        for (int i = 0; i < botFencePF.Length; i++)
        {
            Instantiate(prefabCollection.GetRandomVFencePFPF(), leftFencePF[i].transform.position, Quaternion.identity);
            Destroy(leftFencePF[i]);
        }
    }
    private void LoadRightFence()
    {
        for (int i = 0; i < botFencePF.Length; i++)
        {
            Instantiate(prefabCollection.GetRandomVFencePFPF(), rightFencePF[i].transform.position, Quaternion.identity);
            Destroy(rightFencePF[i]);
        }
    }
    
}
