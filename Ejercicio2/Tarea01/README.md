# 🏥 Ejercicio 2 Tarea 1.

## 📌 Descripción de la Tarea

En este nuevo ejercicio , continuamos con la lógica previa. 

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
- Hemos añadido la funcionalidad del diagnóstico por si el paciente lo requiere.

---

## ❓ ¿Los pacientes que deben esperar para hacerse las pruebas diagnóstico entran luego a hacerse las pruebas por orden de llegada?

No tienen porqué. Ya que aunque los pacientes son atendidos por orden de llegada y se atienden cada 3 segundos, el tiempo de consulta va variando entonces, puede ser que el que ha entrado tercero sea el primero que se haga un diagnóstico, si el primero también lo quiere pero su consulta tarda más que lo que ha tardado el tercero en entrar y hacerse la consulta. 

### 🔍  ¿Qué pruebas he realizado para comprobarlo?
- Para comprobar que existía este comportamiento ha sido con dos opciones, la primera que ir realizando dotnet run hasta que sucediera que el segundo o tercero se hiciera el dianóstico antes de tiempo que uno que haya entrado antes. 
- La otra forma más rápida sería poner que todos quieran realizar diagnóstico y vería si ese comportamiento sucede. 

📌 **Conclusión:**  
> Los pacientes no entran a las pruebas diagnósticas por orden de llegada al hospital, sino por orden de finalización de la consulta, y luego en función de la disponibilidad de las máquinas.
