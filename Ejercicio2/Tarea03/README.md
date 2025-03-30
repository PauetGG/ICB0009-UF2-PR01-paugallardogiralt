# 🏥 Ejercicio 2 Tarea 3.

## 📌 Descripción de la Tarea

En este nuevo tarea , continuamos con la lógica previa de la tarea 2 pero con unas pequeñas modificación. 

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
- En esta tarea cambiamos que en vez de entrar 4 pacientes van a entrar 20 pacientes y llegarán cada dos segundos. Si no hay una consulta médica disponible se tendrán que esperar en EsperaConsulta. 

---

## ❓ Explica la solución planteada en tu código y porqué las has escogido.

En esta parte del ejercicio, lo que he hecho ha sido simular la llegada de 20 pacientes al hospital, uno cada 2 segundos, tal y como se pedía. He mantenido los 4 médicos y las 2 máquinas de diagnóstico, y lo que pasa es que cuando un paciente llega, si no hay ningún médico libre, se queda esperando en el estado de EsperaConsulta hasta que le toque.

Para controlar eso he usado un sistema que limita cuántos pacientes pueden ser atendidos al mismo tiempo (en este caso 4), así que si están todos los médicos ocupados, el resto tiene que esperar su turno. La llegada secuencial la he hecho simplemente con un bucle y un Task.Delay que hace que cada paciente entre 2 segundos después del anterior.

### 🔍  Plantea otra posibilidad de solución a la que has programado.
Podría haber hecho que todos los pacientes llegaran al mismo tiempo al principio y ya esperaran dentro de la sala de espera. Es más fácil de programar porque no hay que controlar los tiempos de llegada. Pero no me parecía tan realista, porque en la vida real los pacientes no llegan todos a la vez, sino poco a poco.

Por eso preferí hacer esta versión, que aunque lleva un poco más de trabajo, representa mejor cómo funciona un hospital en la realidad, con pacientes llegando uno a uno y esperando si las consultas están llenas.

## ❓ ¿Los pacientes que deben esperar entran luego a la consulta por orden de llegada? 
Sí, los pacientes que tienen que esperar porque no hay médicos disponibles entran a la consulta por orden de llegada al hospital. Para asegurarme de que esto realmente se cumple, he hecho varias pruebas.

### 🔍 Tipo de pruebas has realizado para comprobar este comportamiento. 
-  Primeramente, hice que llegaran varios pacientes cada dos segundos, como pide el enunciado, y me fijé en los mensajes de consola, donde se muestra claramente cuándo entra cada paciente a consulta y qué médico lo atiende. Al observar el orden, vi que los pacientes se iban atendiendo exactamente en el mismo orden en que llegaron, aunque tuvieran que esperar.
- La otra prueba que hice fue poner los médicos en default como ocupados y luego se pusieran disponibles para comprobar que el orden de atención era el mismo que el de la llegada. 

📌 **Conclusión:**  
> Gracias a estas pruebas he podido confirmar que, aunque los pacientes tengan que esperar porque no hay médicos disponibles en ese momento, el sistema respeta el orden en que fueron llegando al hospital. Es decir, no se cuela nadie, y todos entran a la consulta por turno, tal como debería pasar en un hospital de verdad. Esto hace que la simulación sea más justa y realista.