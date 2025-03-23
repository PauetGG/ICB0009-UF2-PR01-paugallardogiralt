# 🏥 Ejercicio 1 Tarea 2.

## 📌 Descripción de la Tarea

En esta segunda parte del ejercicio, se mejora la simulación de un hospital añadiendo comportamientos al paciente.

Cada paciente que llega al hospital tiene nuevos datos en relación a antes que son :

- **ID único aleatorio** entre 1 y 100.
- **Tiempo de llegada al hospital**, expresado en segundos (empezando desde 0).
- **Duración de la consulta**, aleatoria entre 5 y 15 segundos.
- **Prioridad médica**, que puede ser:
  - `Emergencia` (nivel 1)
  - `Urgencia` (nivel 2)
  - `Consulta general` (nivel 3)
- **Estado**, que puede ser:
  - `Espera`
  - `Consulta`
  - `Finalizado`

Además:
- Los pacientes **llegan en diferentes momentos**, respetando el tiempo de llegada.
- Se asignan aleatoriamente a médicos disponibles.
- Solo pueden ser atendidos si hay un médico libre.
- El programa imprime en consola el estado del paciente y el médico que lo atiende.

---

## ❓ ¿Cuál de los pacientes sale primero de consulta? 

El paciente que **sale primero de la consulta** es el que **entra antes y tiene el menor tiempo de consulta**.

### 🔍 ¿Por qué?
- Porque cuando llegan los paciente son atendidos directamente ya que todos los médicos están disponibles y tienen un tiempo de llegada al hospital que es diferente en este caso entran cada 3 segundos. 
- Además, cada paciente tiene un tiempo de consulta diferente, que puede ser más corto o largo que los demás.

📌 **Conclusión:**  
> El paciente que sale primero de consulta será el que sumando la combinación entre los segundos de llegada al hospital y los segundos de tiempo en consulta que sea menor.
