using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;

public class FindObjectTest {

	[Test]
	public void VerifyCamera()
    {
       EditorSceneManager.OpenScene("Assets/Middleare.unity");
        var go = GameObject.FindGameObjectWithTag("Cam");
        Assert.IsNotNull(go, "No object found in scene");

    }

    [Test]
    public void VerifyTableContents()
    {
        EditorSceneManager.OpenScene("Assets/Middleare.unity");
        var go = GameObject.FindGameObjectWithTag("Dev");
        Assert.IsNotNull(go, "No object found in scene");

    }

    [Test]
    public void VerifyCueBallContents()
    {
        EditorSceneManager.OpenScene("Assets/Middleare.unity");
        var go = GameObject.FindGameObjectWithTag("CueBall");
        Assert.IsNotNull(go, "No object found in scene");

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator FindObjectTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

    [Test]
    public void ArrayListTest()
    {
        
        var array = new int[1];
        Assert.Catch(typeof(IndexOutOfRangeException), () => array[2] = 10);

    }

}
