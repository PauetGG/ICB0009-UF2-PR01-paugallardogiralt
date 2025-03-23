# 🏥 Ejercicio 1 Tarea 1.

## 📌 Descripción de la tarea
En esta tarea tenemos que simular la atención hospitalaria en la cual tenemos:

- **Una sala de espera**, donde los pacientes llegan y esperan su turno con una capacidad máxima de 20 personas.
- **Cuatro médicos**, que atienden a los pacientes de uno en uno.  
- **Pacientes que llegan cada 2 segundos** y esperan hasta ser atendidos.  
- **Cada consulta dura 10 segundos**, luego el médico queda libre para atender al siguiente paciente.  

---

## 🧵 ¿Cuántos hilos se están ejecutando en este programa?

En esta tarea, teniendo en cuenta que los hilos sirven para hacer una tarea en el mismo tiempo, tenemos: 

### 🔹 **Hilos en la tarea 01**
1. **El hilo principal**  
   - Es el encargado de iniciar el programa y manejar la llegada de pacientes.  

2. **Hasta 4 hilos extra para los médicos**  
   - Cada médico atiende a un paciente en un hilo distinto.  

3. **¿Qué pasa cuando un médico atiende a un paciente?**  
   - Gracias al uso de  `await Task.Delay(10000)`, significa que esperamos diez segundos que tardan en ser atendidos sin bloquear el hilo.
   - Esto permite que el programa use los hilos de manera más eficiente. 

### 🔹 **¿Cuántos hilos hay funcionando?**
- **Siempre hay al menos 1 hilo** (el principal que está ejecutando el programa).  
- **Hasta 4 hilos más** cuando los médicos están ocupados con pacientes.  
- **En total, puede haber hasta 5 hilos funcionando al mismo tiempo.**  
---
## 📌 Tabla del funcionamiento de los hilos

| Evento                          | Hilo Principal | Hilo Médico 1 | Hilo Médico 2 | Hilo Médico 3 | Hilo Médico 4 |
|---------------------------------|---------------|--------------|--------------|--------------|--------------|
| Inicia el programa             | 🟢 Activo     | ❌ Inactivo  | ❌ Inactivo  | ❌ Inactivo  | ❌ Inactivo  |
| Llega Paciente 1               | 🟢 Activo     | ❌ Inactivo  | ❌ Inactivo  | ❌ Inactivo  | ❌ Inactivo  |
| Paciente 1 entra a consulta    | 🟢 Activo     | 🟢 Activo    | ❌ Inactivo  | ❌ Inactivo  | ❌ Inactivo  |
| Llega Paciente 2               | 🟢 Activo     | 🟢 Activo    | ❌ Inactivo  | ❌ Inactivo  | ❌ Inactivo  |
| Paciente 2 entra a consulta    | 🟢 Activo     | 🟢 Activo    | 🟢 Activo    | ❌ Inactivo  | ❌ Inactivo  |
| Llega Paciente 3               | 🟢 Activo     | 🟢 Activo    | 🟢 Activo    | ❌ Inactivo  | ❌ Inactivo  |
| Paciente 3 entra a consulta    | 🟢 Activo     | 🟢 Activo    | 🟢 Activo    | 🟢 Activo    | ❌ Inactivo  |
| Llega Paciente 4               | 🟢 Activo     | 🟢 Activo    | 🟢 Activo    | 🟢 Activo    | ❌ Inactivo  |
| Paciente 4 entra a consulta    | 🟢 Activo     | 🟢 Activo    | 🟢 Activo    | 🟢 Activo    | 🟢 Activo    |
| Paciente 1 sale de consulta    | 🟢 Activo     | 🟢 Libre     | 🟢 Activo    | 🟢 Activo    | 🟢 Activo    |
| Paciente 2 sale de consulta    | 🟢 Activo     | 🟢 Libre     | 🟢 Libre     | 🟢 Activo    | 🟢 Activo    |
| Paciente 3 sale de consulta    | 🟢 Activo     | 🟢 Libre     | 🟢 Libre     | 🟢 Libre     | 🟢 Activo    |
| Paciente 4 sale de consulta    | 🟢 Activo     | 🟢 Libre     | 🟢 Libre     | 🟢 Libre     | 🟢 Libre     |
| Todos los pacientes atendidos  | ✅ Finalizado | ✅ Finalizado | ✅ Finalizado | ✅ Finalizado | ✅ Finalizado |


---
## 🏥 ¿Cuál de los pacientes entra primero en consulta?

Cada vez que entra un paciente en el hospital, directamente se añade a la sala de espera y espera al médico para que lo atienda, entonces el programa proceda de la siguiente forma: 


1. **Los pacientes llegan en orden cada 2 segundos**.  
2. **Cuando hay un médico libre, se le asigna un paciente de manera aleatoria**.  
3. **El primer paciente que entra en consulta será el primero en la lista que encuentre un médico disponible**.  

📌 **Conclusión:**  
- El orden de llegada al hospital, en este caso, garantiza el orden de atención.  
- El paciente que entra primero a consulta será el primero en ser atendido porque todos los médicos están disponibles en el momento de ejecución del programa.  


## ⏳ ¿Cuál de los pacientes sale primero de consulta?

La salida de los pacientes depende del **orden en que entraron a consulta**.

1. **Cada consulta dura 10 segundos**
2. **Si un paciente entra primero, también saldrá primero.**  
3. **El orden de salida depende completamente de qué médico atendió primero.**  

📌 **Conclusión:**  
- Siguiendo la temática de la otra pregunta, como el primero en entrar también es el primero en ser atendido porqué todos los médicos están disponibles, también será el primero en salir.  
