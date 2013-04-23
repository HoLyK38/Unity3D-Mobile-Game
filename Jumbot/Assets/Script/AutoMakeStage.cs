using UnityEngine;
using System.Collections;


public class Node
{
	public static int brickWidth=-1;
	public static int brickHeight=-1;
	public static int nodeWidth=-1;
	public static int nodeHeight=-1;
	
	public Vector3 brickPosition;
	public int number;//this node number(1~9)
	
	public Node(int n)
	{
		if(brickWidth<0 || brickWidth<0 || nodeWidth<0 ||nodeHeight<0)
		{
			MonoBehaviour.print("--Error in Node static value--");
		}
		number = n;
	}
	public void MakeBrickPosition()
	{
		int width = nodeWidth - brickWidth;
		int height = nodeHeight - brickHeight;
		if(width<0 || height<0)
		{
			MonoBehaviour.print("--Error in MakeBrickPosition()--");
			return ;
		}
		brickPosition.x = (float)Random.Range(0,width) + (int)(number%3) * nodeWidth;
		brickPosition.y = (float)Random.Range(0,height) + (int)(number/3) * nodeHeight;
		brickPosition.z = 0;
	}
}

public class Section
{
	public static int sectionHeight = -1;
	public static int sectionWidth = -1;
	
	public Node[] nodes;
	public int number;
	
	public Section(int n)
	{
		if(sectionHeight<0 ||sectionWidth<0)
		{
			MonoBehaviour.print("--Error in Section static value--");
		}
		nodes = new Node[9];
		number = n;
	}
	public void AutoMake()
	{
		for(int i=0;i<9;i++)
		{
			nodes[i] = new Node(i);
			nodes[i].MakeBrickPosition();
			nodes[i].brickPosition.y += number * sectionHeight;
		}
	}
	
}


public class AutoMakeStage : MonoBehaviour {
	public GameObject brick;
	
	public int brickWidth = 3;
	public int brickHeight = 2;
	
	public int sectionEnter;//enter point 1~4
	public int sectionExit;//exit point 1~4
	
	public int sectionWidth = 27;
	public int sectionHeight = 30;
	
	public int sectionSize = 1;
	public Section[] section;
	// Use this for initialization
	void Start () {
		Section.sectionWidth = sectionWidth;
		Section.sectionHeight = sectionHeight;
		Node.brickWidth = brickWidth;
		Node.brickHeight = brickHeight;
		Node.nodeWidth = sectionWidth/3;
		Node.nodeHeight = sectionHeight/3;
		
		section = new Section[sectionSize];
		for(int i=0;i<section.Length;i++)
		{
			MakeSection(i);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	void MakeSection(int n)
	{
		section[n] = new Section(n);
		section[n].AutoMake();
		for(int i=0;i<9;i++)
		{
			GameObject b = (GameObject)Instantiate(brick);
			b.transform.position = section[n].nodes[i].brickPosition;
		}
	}
}
