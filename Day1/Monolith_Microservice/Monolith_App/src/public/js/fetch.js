document.addEventListener('DOMContentLoaded', () => {
    fetch('/courses')
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById('courseRecords');
            data.forEach(course => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${course.CourseID}</td>
                    <td>${course.CourseName}</td>
                    <td>${course.Duration}</td>
                `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => console.error('Error fetching courses:', error));
});