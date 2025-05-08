# Bowling Kata
used for interview process

🎳 Bowling Game Kata – Modo de Juego
🧾 Enunciado
Tu tarea es implementar un sistema de puntuación para un juego de bowling con modos de juego. Actualmente existen tres modos:

🎮 Modo: Classic (modo por defecto)
Reglas normales de bowling.


Strike: 10 puntos + próximos 2 lanzamientos.


Spare: 10 puntos + próximo lanzamiento.


Máximo de 10 frames. Si hay strike o spare en el 10, no hay lanzamientos extra (el juego no los soporta).



🎮 Modo: Training
Cada strike vale 5 puntos base (en lugar de 10), pero el bonus sigue siendo igual (dos próximos lanzamientos).


Todo lo demás funciona como Classic.



🎮 Modo: Inverse
Todos los puntajes se descuentan (se restan en lugar de sumar).


Bonus también se descuentan.


Por ejemplo, un spare normal da -10 puntos - siguiente lanzamiento.



✅ Tareas
Implementar la clase Game, que permite jugar un juego completo (hasta 20 tiros).


Implementar el método Score(), que devuelve el puntaje total al final del juego.


Implementar los tres modos de juego detallados.


Escribir pruebas unitarias para el modo Classic. (Los otros pueden testearse luego, o ser parte de otro paso del desafío.)



