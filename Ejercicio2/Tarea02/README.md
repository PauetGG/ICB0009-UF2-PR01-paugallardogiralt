# 🏥 Ejercicio 2 Tarea 2.

## 📌 Descripción de la Tarea

En este nuevo ejercicio , continuamos con la lógica previa de la tarea 1 pero con una modificación. 

Cada paciente que llega al hospital tiene los sguientes datos que son :

- **ID único aleatorio** entre 1 y 100.
- **Tiempo de llegada al hospital**, expresado en segundos (empezando desde 0).
- **Duración de la consulta**, aleatoria entre 5 y 15 segundos.
- **Duración del diagnóstico** 15 segundos.
- **Prioridad médica**, que puede ser:
  - `Emergencia` (nivel 1)
  - `Urgencia` (nivel 2)
  - `Consulta general` (nivel 3)
- **Estado**, que puede ser:
  - `EsperaConsulta`
  - `Consulta`
  - `EsperaDiagnostico`
  - `Finalizado`
- **Diagnóstico** Si el paciente requiere diagnóstico o no. 

A diferencia del anterior :
- Ahora cuando se requiere que un paciente se haga un diagnóstico no va a esperar el diagnóstico por el orden de terminar la consulta con el médico sino por el orden de llegada en el hospital. 

---

## ❓ Explica la solución planteada en tu código y porqué las has escogido.


En el código se ha implementado un control para que los pacientes que requieren diagnóstico entren a las máquinas respetando el orden en que llegaron al hospital, y no simplemente cuando terminan su consulta. Esto se hace porque si se permite que pasen directamente al diagnóstico al finalizar la consulta, podría darse el caso de que un paciente que llegó más tarde pase antes que otro solo porque su consulta fue más corta.

Para evitar que esto ocurra, he creado una lista ordenada por llegada al hospital y una cola de diafnóstico que se actualiza constantemente. Así, antes de que un paciente se haga un diagnóstico se comprueba si hay alguno que entró antes que él. De esta manera garantizamos el orden respetando el orden de llegada. 

### 🔍  Plantea otra posibilidad de solución a la que has programado.
Una solución alernativa podría haber sido usar un cola de prioridad pero que la prioridad fuera el orden de llegada. 
- En vez de verificar si los anteriores han finalizado, cada paciente tendría una prioridad numérica basada en su llegada.
- Una estructura como SortedSet o una cola con PriorityQueue podría encargarse de mantener el orden sin necesidad de listas auxiliares.
- Cuando una máquina esté libre, se toma directamente el paciente con menor prioridad, sin hacer comprobaciones adicionales de otros pacientes.

📌 **Conclusión:**  
> Los pacientes entran a las pruebas diagnósticas por orden de llegada al hospital  y no por orden de finalización de la consulta y también en función de la disponibilidad de las máquinas. 
