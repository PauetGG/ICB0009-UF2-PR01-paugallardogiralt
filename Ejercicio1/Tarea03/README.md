# 🏥 Ejercicio 1 Tarea 3.

## 📌 Descripción de la Tarea

En esta tercera parte del ejercicio, continuamos con exactamente la misma lógica que en la tarea anterior. 

Cada paciente que llega al hospital tiene los sguientes datos que son :

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

A diferencia del anterior :
- El mensaje que antes había personalizado se mostrará de una manera diferente. 
- Con la siguiente estructura: 
    - Paciente 12. Llegado el 1. Estado: Finalizado. Duración Consulta: 10 segundos.
    - Paciente 34. Llegado el 2. Estado: Consulta. Duración Espera: 0 segundos.
    - Paciente 53. Llegado el 3. Estado: Consulta. Duración Espera: 0 segundos.
    - Paciente 21. Llegado el 4. Estado: Consulta. Duración Espera: 0 segundos.
    - Paciente 12. Llegado el 1. Estado: Consulta. Duración Espera: 0 segundos.

---

## ❓ ¿Has decidido visualizar información adicional a la planteada en el ejercicio?¿Por qué?

Si, he decidido añadir información adicional ya que he considerado que era un poco justa y que faltaba infomación relevante a tener en cuenta. En este caso se trata del id del médico que ha atendido al paciente por si ha habido una complicación y también he considerado oportuno añadir la prioridad del paciente. 

### 🔍 ¿Por qué?
- Porque aunque de momento solo entran 4 pacientes y tenemos 4 médicos para atender si en algún momento no sea así será importante saber la prioridad de los pacientes en caso de que haya varios pacientes cuando un médico esté disponible. 
- Además, saber el id del médico también es importante porque así tenemos registrado qué médico atendió en caso de haber algun problema con la consulta. 

📌 **Conclusión:**  
> A parte de la información que se proporcionaba, he decidido implementar estos dos atributos ya que así habrá más seguridad y control sobre la atención hospitalaria. 
