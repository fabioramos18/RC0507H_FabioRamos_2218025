(function() {
    'use strict';
    var lastId = 0;
    var presenteWrapper = document.getElementById("presente_lista");
    var btnSave = document.getElementById("presente_enviar");
    var removeIcon;
    var updateIcon;
    var presentelist;
  
    function init() {
  
      if (!!(window.localStorage.getItem('presentelist'))) {
        presentelist = JSON.parse(window.localStorage.getItem('presentelist'));
      } else {
        presentelist = [];
      }
      btnSave.addEventListener('click', saveTask);
      showList();
    }
  
    function showList() {
  
      if (!!presentelist.length) {
        getLastTaskId();
        for (var item in presentelist) {
          var task = presentelist[item];
          addTaskToList(task);
        }
        syncEvents();
      }
      
    }
  
    function saveTask(event) {
  
      var task = {
        taskId: lastId,
        PresenteNome: document.getElementById("presente_nome").value,
        PresenteAtual: document.getElementById("presente_dar").value,
        PresenteNivel: document.getElementById("presente_nivel").value
      };
      presentelist.push(task);
      syncTask();
      addTaskToList(task);
      syncEvents();

      lastId++;
    }
  
    function addTaskToList(task) {
  
      var removeIcon = document.createElement('span');
      var element = document.createElement('li');
      var updateIcon = document.createElement('span');
  
      removeIcon.innerHTML = "Apagar da lista/";
      removeIcon.className = "remove_item clickeable";
      removeIcon.setAttribute("title", "Remove");
  
      updateIcon.innerHTML = "Alterar presente";
      updateIcon.className = "update_icon clickeable";
      updateIcon.setAttribute("title", "Update");
  
  
      element.appendChild(removeIcon);
      element.appendChild(updateIcon);
      element.setAttribute("id", task.taskId);
      if(task.PresenteNivel == "Maroto")
      task.PresenteAtual = "Carvão";
      element.innerHTML += "Nome da criança: " + task.PresenteNome + " | Presente da criança: " + task.PresenteAtual + " | Comportamento da criança: " + task.PresenteNivel;
      presenteWrapper.appendChild(element);
    }
  
    function updateTask(event) {
  
      var taskTag = event.currentTarget.parentNode;
      var taskId = taskTag.id;
      var taskToUpdate = findTask(taskId).task;
      var pos = findTask(taskId).pos;
      if (!!taskToUpdate) {
        if(taskToUpdate.PresenteNivel == "Maroto")
        {
            alert("Meninos mal comportados nao recebem presentes!");
        }
        else
        {
        var presente_alterar = prompt("Presente", taskToUpdate.PresenteAtual); //Altera o presente
        if (presente_alterar === null)
        {
            return;
        }
        else if (presente_alterar === "")
        {
            return;
        }
        taskToUpdate.PresenteAtual = presente_alterar;
        presentelist[pos] = taskToUpdate;
        taskTag.lastChild.textContent = "Nome da criança: " + taskToUpdate.PresenteNome + " | Presente da criança: " + taskToUpdate.PresenteAtual  + " | Comportamento da criança: " + taskToUpdate.PresenteNivel; 
         }
        syncTask();
      }
    }
  
    function removeTask(event) {
  
      var taskToRemove = event.currentTarget.parentNode;
      var taskId = taskToRemove.id;
      presenteWrapper.removeChild(taskToRemove);
      presentelist.forEach(function(value, i) {
        if (value.taskId == taskId) {
          presentelist.splice(i, 1);
        }
      })
  
      syncTask();
    }
  
    function syncTask() {
  
      window.localStorage.setItem('presentelist', JSON.stringify(presentelist));
      presentelist = JSON.parse(window.localStorage.getItem('presentelist'));
    }
  
    function getLastTaskId() {
      var lastTask = presentelist[presentelist.length - 1];
      lastId = lastTask.taskId + 1;
    }
  
    function syncEvents() {
  
      updateIcon = document.getElementsByClassName("update_icon");
      removeIcon = document.getElementsByClassName("remove_item");
      if (!!removeIcon.length) {
        for (var i = 0; i < removeIcon.length; i++) {
          removeIcon[i].addEventListener('click', removeTask);
        }
      }
      if (!!updateIcon.length) {
        for (var j = 0; j < updateIcon.length; j++) {
          updateIcon[j].addEventListener('click', updateTask);
        }
      }
    }
  
    function findTask(id) {
  
      var response = {
        task: '',
        pos: 0
      };
      presentelist.forEach(function(value, i) {
        if (value.taskId == id) {
          response.task = value;
          response.pos = i;
        }
      });
  
      return response;
    }
   
    init();
  
  
  })();