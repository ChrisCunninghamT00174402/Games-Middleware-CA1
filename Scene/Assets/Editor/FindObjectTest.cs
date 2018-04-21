﻿using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class FindObjectTest {

	[Test]
	public void FindObjectTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

    [Test]
    public void VerifySceneContents()
    {
        EditorSceneManager.OpenScene("Assets/Middleare.unity");
        var go = GameObject.FindGameObjectWithTag("Dev");
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
}
