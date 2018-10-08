using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudad{
	private string nameCity;
	private bool tieneTaller;
	//private Trayecto[] trayectos = null;

	public Ciudad(string name, bool tieneTaller){
		this.nameCity = name;
		this.tieneTaller = tieneTaller;
	}
	public void GenerarTrayectos(){
		int size = Random.Range(0,3);
		//trayectos = new Trayecto[size];
		for(int i = 0; i <= size; i++){
			string name = "Nombre de trayecto RANDOM " + i;
			//Ciudad ciudad1 = new Ciudad();
			//trayectos[i] = new Trayecto(name);
		}
	}
	// public bool ExisteTrayectos(){
	// 	if(trayectos == null){
	// 		return false; // NO hay trayectos
	// 	}else{
	// 		return true; // hay trayectos
	// 	}
	// }
}
