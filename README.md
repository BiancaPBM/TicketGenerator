LOTTERY APP
Write a lottery "6 out of 49" ticket generator, which automatically fills in a ticket with 1..n boxes
(can be set in the frontend), each consisting out of 6 drawn numbers out of the number range
of 0 to 49 when clicking on a "Draw tickets" button. Each number can only exist once per box.
Background information: to win the jackpot you must match all six main numbers and the
“Superzahl” number. The “Superzahl” is a number from 0 to 9.
Example lottery ticket:Write a lottery "6 out of 49" ticket generator, which automatically fills in a ticket with 1..n boxes
(can be set in the frontend), each consisting out of 6 drawn numbers out of the number range
of 0 to 49 when clicking on a "Draw tickets" button. Each number can only exist once per box.
Background information: to win the jackpot you must match all six main numbers and the
“Superzahl” number. The “Superzahl” is a number from 0 to 9.

In the example you have one lottery ticket with 10 boxes. Each box has 6 numbers filled (which
this application should draw automatically) out of the range from 1 .. 49 per box. There is also
the “Superzahl” (lower left corner) which in this case is the 5. The rest of the lottery ticket
above can be ignored for the sample application.
User workflow:
• Input the amount of boxes (each consisting of 6 out of the numbers 1 to 49) to be
generated
• Click the “Draw tickets” button
• The generated ticket(s) are being persisted in the backend (using an API call) and
displayed in a list (authorization/user management is being left out on purpose to keep
the test smaller) including the “Superzahl” (if selected)
• The result of a saved lottery ticket can be viewed by clicking on it (must be retrieved
from the backend via an API call) and displays all the boxes (and the drawn numbers per
box) and the “Superzahl” (if it was persisted)
Must have:
• Input of the number of boxes to be created per lottery ticket
• Creating the lottery ticket by creating the defined number of boxes, each with 6 drawn
numbers (out of 1 .. 49) per lottery ticket (--> LaPlace experiment)
• Sort drawn numbers in ascending order per box
• Created tickets are persisted in the backend
• Usage of APIs for connection Frontend ↔ Backend
• Saved tickets can be viewed by clicking on them
Bonus:
• Apply CSS animations when drawing numbers (fade, etc ...)
• Input element which defines if a “Superzahl” should be created, persisted and displayed
or not
