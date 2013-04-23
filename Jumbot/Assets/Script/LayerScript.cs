using UnityEngine;
using System.Collections;


public class LayerNode : MonoBehaviour
{
	public LayerNode last = null;
	public LayerNode next = null;
	public ArrayList bricks = new ArrayList();
	public int 		 level;
	public int		 brickSpace = 30;
	public bool LoadScene(int idx)
	{
		AsyncOperation async = Application.LoadLevelAdditiveAsync(idx);
		if(async==null)return false;
		else 		   return true;
	}
	public void FindBrick()
	{
		int i=0;
		while(true)
		{
			GameObject obj = GameObject.Find("Brick(Clone)");
			if(obj!=null)
			{
				obj.name = "Brick" + i;
				bricks.Add(obj);
			}
			else
			{
				break;
			}
			i++;
			if(i>99)
			{
				break;
			}
		}
	}
	public void SetBrickPos()
	{
		for(int i=0;i<bricks.Count;i++)
		{
			float x,y,z;
			x = ((GameObject)bricks[i]).transform.position.x;
			y = ((GameObject)bricks[i]).transform.position.y + brickSpace * (level-1);
			z = ((GameObject)bricks[i]).transform.position.z;
			((GameObject)bricks[i]).transform.position = new Vector3(x,y,z);
			Debug.Log(level);
		}
	}
	~LayerNode()
	{
		bricks = null;
	}
}

public class LayerScript : MonoBehaviour {
	public int layerNodeHeight = 40;
	
	private LayerNode currentLayer = null;
	private int currentLevel = 1;
	
	private int kk = 1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.transform.position.y > currentLevel*layerNodeHeight)
		{
			LayerNode l = currentLayer.next;
			
		}
	}
	void OnGUI()
	{
		if(GUI.Button(new Rect(50,90,80,20), "Layer")) {
			LoadLayer(kk);
			kk++;
		}
		if(GUI.Button(new Rect(50,120,80,20), "qq")) {
			currentLayer = null;
			/*for(int i=0;i<9;i++)
			{
				
				Destroy((GameObject)currentLayer.bricks[i]);
			}*/
		}
	}
	void LoadLayer(int idx)
	{
		/*AsyncOperation async = Application.LoadLevelAdditiveAsync(idx);
        for(int i=0;i<9;i++)
		{
			GameObject obj = GameObject.Find("Brick(Clone)");
			bricks.Add(obj);
			Destroy(obj);
		}
		assignBrick();*/
		LayerNode layerNode = new LayerNode();
		layerNode.level = currentLevel;
		layerNode.last = currentLayer;
		if(currentLayer == null)
		{
			currentLayer = layerNode;
		}
		else
		{
			currentLayer.next = layerNode;
			currentLayer = layerNode;
		}
		if(currentLayer.LoadScene(idx))
		{
			StartCoroutine(WaitAndInit(0.1f));
			currentLevel++;
		}
	}
	IEnumerator WaitAndInit(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        print("WaitAndPrint " + Time.time);
		currentLayer.FindBrick();
		currentLayer.SetBrickPos();
    }
	void DeleteLayer(LayerNode l)
	{
		if(l!=null)
		{
			for(int i=0;i<l.bricks.Count;i++)
			{
				Destroy((GameObject)l.bricks[i]);
			}
			l = null;
		}
	}
}
