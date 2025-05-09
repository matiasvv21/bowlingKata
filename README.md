# Kata: Bowling Club Challenge

## Contexto

Eres un desarrollador trabajando para un club de bolos que ofrece diferentes modalidades de juego. Actualmente tienen implementados dos modos: "Classic" (el bowling tradicional) y "Training" (donde los strikes valen solo 5 puntos base en lugar de 10).

El club quiere expandir su oferta con nuevos modos de juego. Tu tarea es modificar el sistema existente para añadir estas nuevas modalidades sin romper la funcionalidad actual ni modificar su interfaz publica.

## El código existente

El sistema actualmente usa la clase `Game` para calcular la puntuación:

Hay varios tests que verifican el comportamiento tanto del modo "Classic" como del "Training".
### Modo Classic

Reglas normales de bowling.
Strike: 10 puntos + próximos 2 lanzamientos.
Spare: 10 puntos + próximo lanzamiento.
Máximo de 10 frames. Si hay strike o spare en el 10, se habilitan 3 tiros en total en el decimo frame, un juego perfecto tiene 12 tiradas de 10 pinos.

## Tu desafío

Debes extender el sistema para soportar dos nuevos modos de juego:

### 1. Modo "Inverse"
- En este modo, **todos los puntos se restan**, incluso los bonus.
- Un juego perfecto en modo "Inverse" resultaría en -300 puntos.
- Los strikes y spares siguen las mismas reglas para los bonus pero con valores negativos.

### 2. Modo "Alternating"
- En frames pares (2, 4, 6, 8, 10), los strikes valen 15 puntos base en lugar de 10
- En frames impares (1, 3, 5, 7, 9), los strikes valen solo 5 puntos base
- Los spares mantienen su valor normal de 10 puntos

## Restricciones

1. **No puedes modificar la interfaz pública** de la clase Game
2. Debes añadir tests para cada nuevo modo de juego
3. Los modos "Classic" y "Training" deben seguir funcionando exactamente igual

## Puntos extra (opcionales)

1. Refactoriza el código para mejorar su diseño y facilitar futuras extensiones
2. Identifica y comenta los problemas de diseño que encuentres

## Evaluación

Tu solución será evaluada en base a:
1. Correctitud funcional (los tests existentes y nuevos deben pasar)
2. Diseño de la solución (especialmente para los puntos extra)
3. Calidad del código y los tests

## Tiempo recomendado
Aproximadamente 30-40 minutos.


