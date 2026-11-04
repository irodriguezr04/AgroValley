# AgroValley - Proyecto Final

Entorno rural interactivo desarrollado en Unity con soporte para gráficos en Universal Render Pipeline (URP) y el nuevo Input System. El proyecto ambienta una granja tradicional estructurada con zonas de cultivo, elementos arquitectónicos, fauna animada y mecánicas integradas de exploración y respuesta ambiental.

---

## Características Principales

- **Arquitectura gráfica en URP:** Iluminación global optimizada, perfiles de volumen (Post-Processing) y sombreadores (shaders) adaptados para compatibilidad total en tiempo real.
- **Diseño de nivel:**
  - Modelado y texturizado de terreno mediante Terrain Tools con capas combinadas (tierra, césped, rocas y arena).
  - Distribución espacial lógica: vivienda principal, molino, corrales, huertos y cuenca fluvial.
- **Sistema de animación y personajes:**
  - Integración de modelo 3D con rig humanoide y animaciones procedentes de Mixamo.
  - Controlador de tercera persona basado en Starter Assets, desacoplado y adaptado al nuevo sistema de eventos de entrada (Input System).
- **Fauna ambiental integrada:** Animales de granja distribuidos con máquinas de estados de animación en bucle (idle/wander), aportando dinamismo visual al escenario.

---

## Controles y Mecánicas

- **Desplazamiento:** Teclas W, A, S, D para movimiento direccional.
- **Control de cámara:** Movimiento orbital libre con el ratón (perspectiva en tercera persona).
- **Locomoción avanzada:**
  - Espacio: Salto con cálculo de física y detección de suelo (ground check).
  - Shift Izquierdo: Esprint continuo con interpolación de velocidad.
- **Interacción y scripts propios:**
  - **Apertura de accesos (ControlPuerta.cs):** Detección volumétrica por proximidad (Trigger Collider) e interpolación matemática (Slerp/Lerp) para rotación suave al paso del jugador.
  - **Sistema acuático (WaterDetection.cs):** Delimitación del cauce del río con colisionadores de volumen que ajustan los parámetros de movimiento y las transiciones de animación del personaje al sumergirse.

---

## Instalación y Ejecución

### Opción 1: Probar el ejecutable compilado (.exe)
1. Dirígete a la pestaña de [Releases](https://github.com/irodriguezr04/AgroValley/releases) de este repositorio.
2. Descarga el archivo comprimido AgroValley_Build.zip.
3. Descomprime el contenido en una carpeta local.
4. Ejecuta AgroValley.exe.

### Opción 2: Abrir el proyecto en Unity Editor
1. Clona el repositorio en tu máquina:
   ```bash
   git clone [https://github.com/irodriguezr04/AgroValley.git](https://github.com/irodriguezr04/AgroValley.git)
