 
--->> Deployment of Platform Service <<---

          kubectl apply -f platforms-depl.yaml
 --->> Get the deployment of container <<----

          kubectl get deployments
         
          kubectl get pod

          kubectl apply -f platforms-np-srv.yaml
         
          kubectl get services