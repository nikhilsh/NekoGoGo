﻿//using UnityEngine;
//using System.Collections;
//
//public class Square : Shapes {
//	int count = -1;
//	int index = -1;
//
//	void Start(){
//		count = 0;
//		index = 0;
//
//		for (int sides=0 ; sides<4 ; sides++) {
//			if (sides == 0) {
//				// top
//				int y = 3;
//				for (float x = -3; x <= 3; x += 0.2f) {
//					GameObject temp = Instantiate (point, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
//					temp.transform.parent = gameObject.transform;
//					temp.transform.position += temp.transform.parent.position;
//					temp.name = ""+count;
//					count++;
//				}
//			} else if (sides == 1) {
//				// right
//				int x = 3;
//				for (float y = 3; y >= -3; y -= 0.2f) {
//					GameObject temp = Instantiate (point, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
//					temp.transform.parent = gameObject.transform;
//					temp.transform.position += temp.transform.parent.position;
//					temp.name =  ""+count;
//					count++;
//				}
//			} else if (sides == 2) {
//				// bottom
//				int y = -3;
//				for (float x = 3; x >= -3; x -= 0.2f) {
//					GameObject temp = Instantiate (point, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
//					temp.transform.parent = gameObject.transform;
//					temp.transform.position += temp.transform.parent.position;
//					temp.name =  ""+count;
//					count++;
//				}
//			} else {
//				// left
//				int x = -3;
//				for (float y = -3; y <= 3; y += 0.2f) {
//					GameObject temp = Instantiate (point, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
//					temp.transform.parent = gameObject.transform;
//					temp.transform.position += temp.transform.parent.position;
//					temp.name = ""+count;
//					count++;
//				}
//			}
//		}
//	}
//
//
//}
