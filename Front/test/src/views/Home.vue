<template>
  <div class="home">
    <div class="app">
      <div v-for="(el, i) in data" :key="i" style="width: 200px;">
        <img :src="el.url" style="width: 200px; height: 200px; background-size: cover;">
        <br>
        <p>Просмотр {{el.statistic}}</p>
        <br>
        <Button @click="click(el.id)">Лайк</Button>
      </div>
    </div>
  </div>
</template>

<script>

import {mapActions, mapGetters} from 'vuex'
import Button from "@/components/Button";
export default {
  name: "Home",
  data() {
    return {
      value: "",
      data: []
    };
  },
  components: {
    Button
    // Button,
  },
  async mounted() {
    await this.fetchImages()
    this.data = this.images
  },
  watch: {
    images(val) {
      console.log(val)
      this.data = val
    }
  },
  computed:{
    ...mapGetters({
      images: "getImages"
    })
  },
  methods: {
    ...mapActions({
      fetchImages: "fetchImages",
      updateImage: "updateImage"
    }),
    click(id, userId = 1) {
      this.updateImage({
        imageId: id,
        userId: userId
      })
    }
  }
};
</script>
<style lang="scss" scoped>
.app {
  height: 100vh;
  display: grid;
  grid-template-columns: 1fr 1fr;
  margin: 50px 50px;
  &__left,
  &__right {
    display: flex;
    align-items: center;
    justify-content: center;
  }

  &__left {
    position: relative;

    &::after {
      content: "";
      position: absolute;
      display: block;
      height: 85%;
      right: -1px;
      width: 2px;
      background: #e4e4e4;
    }
  }
}

.main-btn{
  max-width: 230px;
}
</style>
