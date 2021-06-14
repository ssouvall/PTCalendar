# Pro-Chart EMR

![Image of HTML5 shield](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white) ![Image of CSS shield](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white
) ![Image of JavaScript shield](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black) ![Image of Bootstrap logo](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white) ![Image of C# Logo](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) ![Image of .NET logo](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
 ![Image of JQuery logo](https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
) ![Image of PostgreSQL shield](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white
) ![Image of Heroku Shield](https://img.shields.io/badge/Heroku-430098?style=for-the-badge&logo=heroku&logoColor=white)

Pro-Chart is a calendar and mock physical therapy electronic medical records application. It is built to simulate a real physical therapy clinic's charting system, with the ability to create, read, update, and delete patient appointments as well as patient chart records.

### Features and Functionality
##### Authentication and Roles
-Implements authentication \
-Implements role-based priveleges as follows:
  1. Admin user:
    -CAN: Add, edit, and remove appointments \
    -CAN: Add, edit, and remove patients \
    -CANNOT: Add, edit, or remove patient visit notes from patient charts 
  2. Physical Therapist user:
    -CAN: Add, edit, and remove appointments \
    -CAN: Add and edit patients \
    -CAN: Add, edit, and remove patient visit notes from patient charts \
    -CANNOT: Delete patients 
  3. Clerical user:
    -CAN: Add, edit, and remove appointments \
    -CAN: Add and edit patients \
    -CANNOT: Delete patients \
    -CANNOT: Add, edit, or remove patient visit notes from patient charts \
-Logged in roles can only see buttons and features they are permitted to use, features that they do not have priveleges to use are not visible \
-Allows demo login with ability to login as a demo admin, demo PT, or demo clerical user 

##### Calendar
-Graphical calendar with day, week, and month views \
-Ability to add, read, update, and delete patient appointments \
-Ability to drag and drop appointments to new locations \
-Rules limiting appointments to be made for dates in the past \
-Rule of only one visit per hour \
-Ability to to click on calendar appointment and see appointment details, where you can navigate to patient chart, edit appointment, or delete appointment 

##### Patient Charts
-Create, read, update, and delete a patient chart \
-A physical therapist (when logged in) can create, update, and delete individual visit notes 


