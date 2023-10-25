// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*script.js*/
function handleSearch(event) {
    if (event.key === "Enter") {
        const searchQuery = event.target.value;
        // Perform the search with the searchQuery
        // You can add your search logic here
        alert(`Searching for: ${searchQuery}`);
    }
}
