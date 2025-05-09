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


✅ Tareas

Se desea agregar el modo "Inverse" sin romper los tests existentes:
En este modo, todos los puntos se restan, incluso los bonus.
Por ejemplo, un spare normal da -10 puntos - siguiente lanzamiento.

Si encontrás problemas de diseño, comentá cómo lo mejorarías y por qué.

(Bonus): Refactorizá el código para facilitar futuros cambios si tenés tiempo.



