

using UnityEngine;
using UnityEngine.UI;

public class foodMaker : MonoBehaviour
{
    private static foodMaker _instance;
    public static foodMaker Instance
    {
        get
        {
            return _instance;
        }
    }

    public int xlimit = 21;
    public int ylimit = 11;
    public int xoffset = 9;
    public GameObject foodPrefab;
    public GameObject rewardPrefab;
    public Sprite[] foodSprites;
    private Transform foodHolder;

    
    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        foodHolder = GameObject.Find("foodHolder").transform;
        makeFood(false);
    }

    public void makeFood(bool isReward)
    {
        int index = Random.Range(0, foodSprites.Length);
        GameObject food = Instantiate(foodPrefab);
        food.GetComponent<Image>().sprite = foodSprites[index];
        food.transform.SetParent(foodHolder, false);
        int x = Random.Range(-xlimit + xoffset, xlimit);
        int y = Random.Range(-ylimit, ylimit);
        food.transform.localPosition = new Vector3(x * 30, y * 30, 0);
        if (isReward)
        {
            GameObject reward = Instantiate(rewardPrefab);
            reward.transform.SetParent(foodHolder, false);
            x = Random.Range(-xlimit + xoffset, xlimit);
            y = Random.Range(-ylimit, ylimit);
            reward.transform.localPosition = new Vector3(x * 30, y * 30, 0);
        }
    }
}
