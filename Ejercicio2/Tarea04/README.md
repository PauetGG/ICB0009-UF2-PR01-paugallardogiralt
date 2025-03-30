# 🏥 Ejercicio 2 Tarea 4.

## 📌 Descripción de la Tarea

En este nuevo tarea , continuamos con la lógica previa de la tarea 3 pero con una pequeña modificación. 

Cada paciente que llega al hospital tiene los sguientes datos que son :

- **ID único aleatorio** entre 1 y 100.
- **Tiempo de llegada al hospital**, expresado en segundos (empezando desde 0 y luego de dos en dos).
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
- En esta tarea el cambio que tenemos está en el orden de ser atendidos los pacientes cuando se encuentran en la EsperaConsulta ya que priorizamos las emergencias y en caso de empate de emergencia al orden de llegada. También tenemos en cuenta en este apartado que según mi lógica los médicos están disponibles o cuando están esperando el diagnóstico o cuando han finalizado la consulta, ya que creo que cuando se hacen el diagnóstico se la tienen que hacer en un laboratorio automatizado. 

---

## ❓ Explica la solución planteada en tu código y porqué las has escogido.

En este apartado, he modificado el sistema de atención para que los pacientes que están en espera entren a la consulta según su prioridad médica, y si hay varios con la misma prioridad, se respete el orden en que llegaron al hospital.
Esto lo he hecho reemplazando la cola de espera (Queue) por una lista ordenada dinámicamente. Así puedo controlar mejor el orden de los pacientes, ya que puedo ordenar esa lista cada vez que se quiera atender a alguien, primero por prioridad y luego por llegada.

He escogido esta solución porque me parece más clara, flexible y realista. En un hospital, no siempre se atiende en el orden de llegada, sino según la gravedad del caso. Con esta lista puedo garantizar ese comportamiento sin complicarme con estructuras más rígidas como una cola.

### 🔍  Plantea otra posibilidad de solución a la que has programado.
Otra forma de hacerlo habría sido mantener la cola original y recorrerla manualmente para buscar el paciente más prioritario cada vez que se va a atender. Después, reconstruir la cola quitando ese paciente.
Funciona, pero es más propenso a errores y requiere reescribir la cola constantemente, lo cual no es tan limpio.

📌 **Conclusión:**  
> Con esta solución he conseguido que los pacientes se atiendan de forma más lógica, primero los más urgentes y luego el resto según cuándo llegaron. Me pareció la forma más clara y realista de hacerlo, y además me dio más control sobre el orden sin complicarme demasiado el código. 