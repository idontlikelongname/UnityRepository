using UnityEngine;
using System.Collections;
using ProgressBar;

public class ProgressTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(www!=null&&!www.isDone)
        {
            ProgressRadialBehaviour PRB = ProgressRadialBehaviour.Instance();
            PRB.Value = www.progress*100f;
        }

        if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(BeginLoader());

	}

    private WWW www;
    private IEnumerator BeginLoader()
    {
        www = WWW.LoadFromCacheOrDownload("www.taobao.com", 1);
        yield return www;

        if(!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("加载场景出错");
        }

        if(www.isDone)
        {
            Debug.Log("加载完成");

            //Application.LoadLevel("MainScene");
        }

    }

    public void Add()
    {
        ProgressRadialBehaviour PRB = ProgressRadialBehaviour.Instance();
        float value = PRB.Value;
        PRB.IncrementValue(5);

        Debug.Log("Add from " + value.ToString());
    }

    public void Minus()
    {
        ProgressRadialBehaviour PRB = ProgressRadialBehaviour.Instance();

        float value = PRB.Value;
        PRB.DecrementValue(5);

        Debug.Log("Minus from " + value.ToString());
    }
}
