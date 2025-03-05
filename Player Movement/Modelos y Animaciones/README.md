## Cualquier modelo .fbx puede ser seleccionado, las animaciones deben ser configuradas en el Motor Unity

![Imagenes](./Imagenes/Modelo%20de%20personaje.png)

## Debemos mover la MainCamara como hijo del Modelo del jugador.
## Asignamos el script de PlayerMovement al Modelo del Jugador y el script de FPCameraMove a la camara. Tambien asignamos los siguietes parametros.

![Imagenes](./Imagenes/Parametros%20de%20Personaje.png)
![Imagenes](./Imagenes/Parametros%20de%20FPCamara.png)

## Las animaciones deben ser ajustadas con respecto al modelo que usemos.
## Desde el Inspector debemos modificar los campos "Rig" y "Animation"
![Imagenes](./Imagenes/Configuracion%20de%20Rig%20en%20Animaciones.png)
![Imagenes](./Imagenes/Configuracion%20de%20Animation%20en%20Animaciones.png)

## El Animator Controller esta configurado con BlendTrees que intercalan segun las acciones del personaje
## (en el .RAR se encuentran las animaciones por separado y el Animator Controller)
![Imagenes](./Imagenes/Arbol%20de%20Animaciones.png)
