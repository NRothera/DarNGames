﻿document.querySelectorAll(".drop_zone__input").forEach((inputElement) => {
    const dropZoneElement = inputElement.closest(".drop_zone");

    dropZoneElement.addEventListener("click", (e) => {
        inputElement.click();
    });

    inputElement.addEventListener("change", (e) => {
        if (inputElement.files.length) {
            updateThumbnail(dropZoneElement, inputElement.files[0]);
        }
    });

    dropZoneElement.addEventListener("dragover", (e) => {
        e.preventDefault();
        dropZoneElement.classList.add("drop_zone__over");
    });

    ["dragleave", "dragend"].forEach((type) => {
        dropZoneElement.addEventListener(type, (e) => {
            dropZoneElement.classList.remove("drop_zone__over");
        });
    });

    dropZoneElement.addEventListener("drop", (e) => {
        e.preventDefault();

        if (e.dataTransfer.files.length) {
            inputElement.files = e.dataTransfer.files;
            updateThumbnail(dropZoneElement, e.dataTransfer.files[0]);
        }

        dropZoneElement.classList.remove("drop_zone__over");
    });
});

/**
 * Updates the thumbnail on a drop zone element.
 *
 * @param {HTMLElement} dropZoneElement
 * @param {File} file
 */
function updateThumbnail(dropZoneElement, file) {

    let thumbnailElement = dropZoneElement.querySelector(".drop-zone__thumb");

    // First time - remove the prompt
    if (dropZoneElement.querySelector(".drop_zone__prompt")) {
        dropZoneElement.querySelector(".drop_zone__prompt").remove();
    }

    // First time - there is no thumbnail element, so lets create it
    if (!thumbnailElement) {
        thumbnailElement = document.createElement("div");
        thumbnailElement.classList.add("drop_zone__thumb");
        dropZoneElement.appendChild(thumbnailElement);
    }

     var fileInput = document.getElementById("imageUpload");
   
     var files = fileInput.files;
    for (var i = 0; i < files.length; i++) {
        var newImage = document.createElement("img");
        var dropZone = document.querySelector("#imageZone");

         thumbnailElement.dataset.label = files[i].name;

         // Show thumbnail for image files
         if (files[i].type.startsWith("image/")) {
             const reader = new FileReader();
             var temp = files[i];
             reader.readAsDataURL(temp);
             reader.onload = (e) => {
                 reader.readAsDataURL(temp);
                 thumbnailElement.style.backgroundImage = `url('${reader.result}')`;
                 const dropZoneElement = document.getElementById("imageUpload");
                 newImage.src = reader.result;
                 dropZone.appendChild(newImage);
                 dropZoneElement.setAttribute('value', reader.result);
                 console.log(reader.result)
             };
         } else {
             thumbnailElement.style.backgroundImage = null;
         }
     }
    

    
}

    

