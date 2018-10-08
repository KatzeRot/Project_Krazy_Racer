using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trayecto {
	private string nameWay;
	private Ciudad ciudad1 = null;
	private Ciudad ciudad2 = null;

	public Trayecto(string nameWay, Ciudad ciudad1, Ciudad ciudad2){
		this.nameWay = nameWay;
		this.ciudad1 = ciudad1;
		this.ciudad2 = ciudad2;
	}
}
