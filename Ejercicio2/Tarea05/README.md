# 🏥 Ejercicio 2 Tarea 5.

## 📌 Descripción de la Tarea

En este nuevo tarea , continuamos con la lógica previa de la tarea 4 pero con una pequeña modificación. 

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
- En esta tarea, el objetivo es hacer un recuento de todo los datos de la jornada laboral en el hospital y calcular el promedio del tiempo de espera de los pacientes, el promedio de uso de las máquinas de diagnóstico y el número total de pacientes atendidos por prioridad. 

---

## ❓ Explición del código

En este apartado, he añadido al final de la simulación un sistema de estadísticas para ver cómo ha ido el día en el hospital. Lo que se muestra es el número total de pacientes atendidos por prioridad (emergencias, urgencias y consultas generales), el tiempo promedio que han esperado antes de ser atendidos, y el porcentaje de uso de las máquinas de diagnóstico.

Para hacerlo, he ido guardando algunos datos durante la ejecución: por ejemplo, cada paciente registra cuánto tiempo ha estado en espera antes de entrar a consulta, y el hospital calcula cuánto tiempo han estado en uso las máquinas de diagnóstico usando un Stopwatch. Al final del día, se calculan los promedios y se muestra todo junto como resumen.

### 🔍  ¿Por qué?
He escogido esta forma porque me parece útil y clara para entender si el sistema está funcionando bien. Además, da una visión general del rendimiento del hospital, como si fuera un informe de fin de turno. Es simple de implementar y muestra información muy útil para evaluar el funcionamiento del programa.

📌 **Conclusión:**  
> Con esta solución puedo ver de forma rápida y clara cómo ha ido la jornada en el hospital. Me permite analizar el rendimiento, los tiempos de espera y el uso de recursos, y todo sin complicar demasiado el código. Me parece una forma sencilla pero muy útil de cerrar la simulación.